using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace YBYinHaiLibrary
{
     
    public static class YinHaiHelper
    {

        /// <summary>
        /// 银海调用后生成结果 Result Model
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dic"></param>
        public static void CreateResultModel(this DealModel dealModel, YinHaiModelBase ResultModel = null)
        {
            //dynamic obj = ResultType.Assembly.CreateInstance(ResultType.Name);
            if (ResultModel != null)
            {
                dealModel.ReslutModel = ResultModel;
            }

            if (dealModel.ReslutModel == null)
            {
                dealModel.ReslutModel = new YinHaiModelBase();
            }

            dealModel.ReslutModel.status = dealModel.IsYanHaiSuccess ;
            dealModel.ReslutModel.msg = dealModel.Msg;


            //如果银行的接口没有成功，直接return
            if (!dealModel.IsYanHaiSuccess)
            {
                return;
            }

            //调用Call返回交易编号等
            dealModel.ReslutModel.callcode = dealModel.astr_jyyzm;
            dealModel.ReslutModel.callno = dealModel.astr_jylsh;

            if (dealModel.ReslutModel.GetType().Name == "YinHaiModelBase")
            {
                return;
            }

            //判断从文件获取还是从返回结果获取
            if (string.IsNullOrWhiteSpace(dealModel.OutputFilePath))
            {
                ParseXMLToModel(dealModel);
            }
            else
            {
                ParseFileToModel(dealModel);
            }

            dealModel.ReslutModel.msg = dealModel.Msg;


        }

        /// <summary>
        /// 文件转Result Model
        /// </summary>
        /// <param name="dealModel"></param>
        /// <returns></returns>
        private static bool ParseFileToModel(DealModel dealModel)
        {
            char FileSplitChar = '\t';

            if (!File.Exists(dealModel.OutputFilePath))
            {
                dealModel.Msg += "文件为找到";
                return false;
            }
              
            //拿到对象的Items List属性
            var itemsField = dealModel.ReslutModel.GetType().GetFields().Where(P => P.Name.ToLower() == "items").FirstOrDefault();
            if (itemsField == null)
            {
                dealModel.Msg = "当前对象没有Items 属性";
                return false;
            }

            //创建 List 对象
            var entityList = Activator.CreateInstance(itemsField.FieldType);

            //绑定List对象到model类
            itemsField.SetValue(dealModel.ReslutModel, entityList);
             
            string[] allLines = File.ReadAllLines(dealModel.OutputFilePath,Encoding.Default);
            //文件没有标头
            //string[] AllHeader = allLines[0].Split(FileSplitChar);
            //所有到数据
            for (int i = 0; i < allLines.Length; i++)
            {
                string[] allData = allLines[i].Split(FileSplitChar);

                try
                {
                    //创建List 泛型里的类实例
                    var subItem = itemsField.DeclaringType.Assembly.CreateInstance(itemsField.FieldType.GenericTypeArguments[0].FullName);

                    var allFields = subItem.GetType().GetFields();
                    for (int j = 0; j < allFields.Length; j++)
                    {
                        //var properties = subItem.GetType().GetFields().Where(P => (P.GetCustomAttribute(typeof(YinHaiAttribute), false) as YinHaiAttribute)?.XmlAttName.ToLower() == AllHeader[h].ToLower()).FirstOrDefault();
                        //properties.SetValue(subItem, allData[h]);

                        if (j < allData.Length)
                        {
                            allFields[j].SetValue(subItem, allData[j]);
                        }
                        else
                        {
                            LogHelper.AddParseMsg("文件转换中的Item和对象的属性不一致");
                        }
                    }
                    

                    ////循环所有的标题
                    //for (int h = 0; h < AllHeader.Length; h++)
                    //{
                    //    //获取子类所有属性并赋值
                    //    var properties = subItem.GetType().GetFields().Where(P => (P.GetCustomAttribute(typeof(YinHaiAttribute), false) as YinHaiAttribute)?.XmlAttName.ToLower() == AllHeader[h].ToLower()).FirstOrDefault();
                    //    properties.SetValue(subItem, allData[h]);
                    //}

                    //讲子类添加到List 里
                    BindingFlags flag = BindingFlags.Instance | BindingFlags.Public;
                    MethodInfo methodInfo = entityList.GetType().GetMethod("Add", flag);
                    methodInfo.Invoke(entityList, new object[] { subItem });//相当于List<T>调用Add方法

                    Console.WriteLine();

                }
                catch (Exception ex)
                {
                    dealModel.Msg = "异常" + ex.Message;
                }

            }

            return true;

        }

        /// <summary>
        /// 测试，作废
        /// </summary>
        /// <param name="model"></param>
        private static void SetValue(Object model)
        {

            //拿到对象的Items List属性
            var itemsField = model.GetType().GetFields().Where(P => P.Name.ToLower() == "items").FirstOrDefault();
            if (itemsField == null)
            {
                //当前类没有 items属性
                return;
            }
            //创建 List 对象
            var entityList = Activator.CreateInstance(itemsField.FieldType);



            //绑定List对象到model类
            itemsField.SetValue(model, entityList);

            //创建List 泛型里的类实例
            var subItem = itemsField.DeclaringType.Assembly.CreateInstance(itemsField.FieldType.GenericTypeArguments[0].FullName);

            //获取子类所有属性并赋值
            var allProperties = subItem.GetType().GetFields();
            for (int i = 0; i < allProperties.Length; i++)
            {
                //给子类属性赋值
                YinHaiAttribute atturn = allProperties[i].GetCustomAttribute(typeof(YinHaiAttribute), false) as YinHaiAttribute;
                if (atturn != null)
                {
                    //if (dic.TryGetValue(atturn.XmlAttName.ToLower().Trim(), out string value))
                    //{
                    //    allProperties[i].SetValue(dealModel.ReslutModel, value);
                    //}
                }
            }

            //讲子类添加到List 里
            BindingFlags flag = BindingFlags.Instance | BindingFlags.Public;
            MethodInfo methodInfo = entityList.GetType().GetMethod("Add", flag);
            methodInfo.Invoke(entityList, new object[] { subItem });//相当于List<T>调用Add方法


        }




        /// <summary>
        /// Dic 转Result Model
        /// </summary>
        /// <param name="dealModel"></param>
        private static void ParseXMLToModel(DealModel dealModel)
        {
            //如果xml是顶层
            if (!dealModel.IsRows)
            {
                Dictionary<string, string> dic = XMLHelper.GetDicFromXML(dealModel.astr_jysc_xml, dealModel.ResultXmlXpath);
                Type type = dealModel.ReslutModel.GetType();
                var allProperties = type.GetFields();

                for (int i = 0; i < allProperties.Length; i++)
                {
                    YinHaiAttribute atturn = allProperties[i].GetCustomAttribute(typeof(YinHaiAttribute), false) as YinHaiAttribute;
                    if (atturn != null)
                    {
                        if (dic.TryGetValue(atturn.XmlAttName.ToLower().Trim(), out string value))
                        {
                            allProperties[i].SetValue(dealModel.ReslutModel, value);
                        }
                    }
                }
            }
            else
            {
                //根据xml rows获取多个Dic，然后转换为model的items
                Dictionary<string, string>[] dicArray = XMLHelper.GetDicArrayFromXML(dealModel.astr_jysc_xml, dealModel.ResultXmlXpath);
                 
                //拿到对象的Items List属性
                var itemsField = dealModel.ReslutModel.GetType().GetFields().Where(P => P.Name.ToLower() == "items").FirstOrDefault();
                if (itemsField == null)
                {
                    dealModel.Msg += "--当前对象没有Items 属性";
                    return;
                }
                //创建 List 对象
                var entityList = Activator.CreateInstance(itemsField.FieldType);

                //绑定List对象到model类
                itemsField.SetValue(dealModel.ReslutModel, entityList);
 
                //所有到数据
                for (int i = 0; i < dicArray.Length; i++)
                {
                   
                    try
                    {
                        //创建List 泛型里的类实例
                        var subItem = itemsField.DeclaringType.Assembly.CreateInstance(itemsField.FieldType.GenericTypeArguments[0].FullName);

                        foreach (var item in dicArray[i].Keys)
                        {
                            //获取子类所有属性并赋值
                            var properties = subItem.GetType().GetFields().Where(P => (P.GetCustomAttribute(typeof(YinHaiAttribute), false) as YinHaiAttribute)?.XmlAttName.ToLower() == item).FirstOrDefault();

                            if (properties!= null)
                            {
                                properties.SetValue(subItem, dicArray[i][item]);
                            }
                            else
                            {
                                //Model 里忘了封装 属性了。。。
                                dealModel.Msg = "--当前对象没找到标记为此的属性"  + item ;
                            }
                            
                        }

                        //讲子类添加到List 里
                        BindingFlags flag = BindingFlags.Instance | BindingFlags.Public;
                        MethodInfo methodInfo = entityList.GetType().GetMethod("Add", flag);
                        methodInfo.Invoke(entityList, new object[] { subItem });//相当于List<T>调用Add方法
                         
                    }
                    catch (Exception ex)
                    {
                        dealModel.Msg = "--异常" + ex.Message;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static Dictionary<string, string>[] ConvertArrayModelToDicArray(Object[] models)
        {
            List<Dictionary<string, string>> items = new List<Dictionary<string, string>>();
            for (int i = 0; i < models.Length; i++)
            {
                items.Add(ConvertModelToDic(models[i]));
            }
            return items.ToArray();
        }
        
        /// <summary>
        /// Model 转Dic 对象
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> ConvertModelToDic(Object model)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (model == null)
            {
                return dic;
            }
            
            //获取子类所有属性并赋值
            var allProperties = model.GetType().GetFields();
            for (int i = 0; i < allProperties.Length; i++)
            {
                //给子类属性赋值
                YinHaiAttribute atturn = allProperties[i].GetCustomAttribute(typeof(YinHaiAttribute), false) as YinHaiAttribute;
                if (atturn != null)
                {
                    dic.Add(atturn.XmlAttName.ToLower().Trim(), allProperties[i].GetValue(model)?.ToString() ?? "");
                }
            }
            return dic;
        }

    }
}