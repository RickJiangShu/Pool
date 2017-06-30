# Pool
效率最高的对象池

解决问题1：每次Push、Pull的时候需要GetCompoent


疑问1：为什么不直接用object作类型？  
因为这样会产生大量的强转类型操作  

设计思路  

添加  
1、Add GameObject or Component  
2、封装成 ObjectItem  
3、设置    

取出
1、Get GameObject or Component  
2、从 ObjectItem 取出  
3、重置  