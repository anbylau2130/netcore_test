接口中数据校验

1，System.ComponentModel.DataAnnotations命名空间下包含一些校验属性

2.处于单一职责原则，不建议使用DataAnnotations中Required等Attitude属性。建议使用FluentValidation


FluentValidation使用


1.安装install-package FluentValidation.AspNetCore

2.Program.cs中增加一下代码
builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssembly(Assembly.GetEntryAssembly());
});

3.编写模型类