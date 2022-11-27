# 项目基础设计

## Entity层

BaseModel：作用，1.用于标注当前的集成BaseModel的模型都是数据库模型，2.规范主键。

DataModel：用于查询数据时的一些常用的参数集合，原框架放置于 `Core` 文件夹下

## Core层

### EntityFrameworkCore包：

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Tools
Pomelo.EntityFrameworkCore.MySql
```

### 服务注册中心

引入Autofac包

- Autofac
- Autofac.Extensions.DependencyInjection

在 ContainerBuilder 上扩展方法
