# Pool
效率最高的对象池

解决问题1：每次Push、Pull的时候需要GetCompoent


疑问1：为什么不直接用Object作类型？  
因为这样就不用在存取GameObject作强转类型，只需要在取Component的时候强转一次；  

设计思路  

添加  
1、Add GameObject or Component  
2、封装成 ObjectItem  
3、设置    

取出
1、Get GameObject or Component  
2、从 ObjectItem 取出  
3、重置  