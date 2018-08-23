
### 检测程序是否启动，启动返回"success"
http://127.0.0.1:8989/API/YiBao/IsStart

### 初始化医保接口
http://127.0.0.1:8989/API/YiBao/InitProcess

### 1.9.1.	获取医保中心日期（52）
http://127.0.0.1:8989/API/YiBao/GetYiBaoDate

### 1.9.2.	获取医院信息（04）
http://127.0.0.1:8989/API/YiBao/GetHospitalInfo

### 1.9.3.	获取医院开通支付类别(05a)
http://127.0.0.1:8989/API/YiBao/GetPayType?centerCode=345&zhengce=344

### 1.9.4.	编码对照信息获取
http://127.0.0.1:8989/API/YiBao/GetCodeInfo

### 1.9.5.	获取中心医保标准目录
http://127.0.0.1:8989/API/YiBao/GetYibaoStandCategory?date=2018-07-01

### 1.9.6.	获取中心目录变更日志
http://127.0.0.1:8989/API/YiBao/GetCenterChangeLog?startDate=2017-01-01&endDate=2018-07-20

### 1.9.7.	获取中心IDC10日志下载
http://127.0.0.1:8989/API/YiBao/GetCenterICD10Data

### 1.9.8.	获取中心IDC10日志下载
【POST】  单个Model
http://127.0.0.1:8989/API/YiBao/SetCategoryUpload

【POST】 多个Model
http://127.0.0.1:8989/API/YiBao/SetCategoryUploadMuit

### 1.9.9.	查询上传目录
http://127.0.0.1:8989/API/YiBao/QueryUploadCategory?datetime=2018-01-01

### 1.9.10.	删除上传目录
http://127.0.0.1:8989/API/YiBao/DeleteCategory

### 1.9.11.	 身份识别
http://127.0.0.1:8989/API/YiBao/UserIdentity

### 1.9.12.	 修改密码
http://127.0.0.1:8989/API/YiBao/ChangePassword

### 1.9.13.	 门诊结算
【POST】
http://127.0.0.1:8989/API/YiBao/MenZhenCheckOut

### 1.9.13.	 申请清算
【POST】
http://127.0.0.1:8989/API/YiBao/QingsuanShenqing

###  清算查询
http://127.0.0.1:8989/API/YiBao/QingsuanShenqingQuery?qingsuanNo=xxx

###  清算单明细打印
【POST】
http://127.0.0.1:8989/API/YiBao/qingsuanmingxi

###  清算申请单打印
【POST】
http://127.0.0.1:8989/API/YiBao/qingsuanshenqing

###  清算回退
【POST】
http://127.0.0.1:8989/API/YiBao/QingsuanShenqingBack


###  结算回退
【POST】
http://127.0.0.1:8989/API/YiBao/JiesuanBack


### 交易取消
http://127.0.0.1:8989/API/YiBao/yhCancel?callno=xxx&callcode=xxx

### 交易确认
http://127.0.0.1:8989/API/YiBao/yhConfirm?callno=xxx&callcode=xxx

### 挂起交易查询
http://127.0.0.1:8989/API/YiBao/yhGetuncertaintytrade?callno=xxx


### 门诊特殊病申请
http://127.0.0.1:8989/API/YiBao/menzhenteshu?name=xxx
