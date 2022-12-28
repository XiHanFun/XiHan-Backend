﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:Program
// Guid:fccfeb28-624c-41cb-9c5c-0b0652648a6b
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-17 下午 04:01:21
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using Microsoft.AspNetCore.HttpOverrides;
using Serilog;
using System.Reflection;
using ZhaiFanhuaBlog.Api;
using ZhaiFanhuaBlog.Api.Extensions;
using ZhaiFanhuaBlog.Extensions.Middlewares;
using ZhaiFanhuaBlog.Extensions.Setups;
using ZhaiFanhuaBlog.Utils.Console;

var builder = WebApplication.CreateBuilder(args);

#region 日志

"Log Start……".WriteLineWarning();
var log = builder.Logging;
log.AddLogSetup();
"Log Started Successfully！".WriteLineSuccess();

#endregion

try
{
    #region 配置

    "Configuration Start……".WriteLineWarning();
    var config = builder.Configuration;
    config.AddConfigSetup();
    "Configuration Started Successfully！".WriteLineSuccess();

    #endregion

    #region 服务

    "Services Start……".WriteLineWarning();
    var services = builder.Services;
    // Cache
    services.AddCacheSetup();
    // Auth
    services.AddAuthJwtSetup();
    // 健康检查
    services.AddHealthChecks();
    // Http
    services.AddHttpSetup();
    // Swagger
    services.AddSwaggerSetup();
    // 性能分析
    services.AddMiniProfilerSetup();
    // SqlSugar
    services.AddSqlSugarSetup();
    // 服务注册
    services.AddServiceSetup();
    // AutoMapper
    services.AddAutoMapperSetup();
    // Route
    services.AddRouteSetup();
    // Cors
    services.AddCorsSetup();
    // Controllers
    services.AddControllersSetup();
    "Services Started Successfully！".WriteLineSuccess();

    #endregion

    #region 应用

    "ZhaiFanhuaBlog Application Start……".WriteLineWarning();
    var app = builder.Build();
    // 初始化数据库
    app.Services.InitDatabase();
    // 环境变量，开发环境
    if (app.Environment.IsDevelopment())
    {
        // 生成异常页面
        app.UseDeveloperExceptionPage();
    }
    else
    {
        // 使用HSTS的中间件，该中间件添加了严格传输安全头
        app.UseHsts();
    }
    // Nginx 反向代理获取真实IP
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });
    // 强制https跳转
    app.UseHttpsRedirection();
    // MiniProfiler
    app.UseMiniProfilerMiddleware();
    // Swagger
    app.UseSwaggerMiddleware(() => Assembly.GetExecutingAssembly().GetManifestResourceStream("ZhaiFanhuaBlog.Api.index.html")!);
    // 使用静态文件
    app.UseStaticFiles();
    // 路由
    app.UseRouting();
    // 跨域
    app.UseCorsMiddleware();
    // 鉴权
    app.UseAuthentication();
    // 授权
    app.UseAuthorization();
    // 配置运行状况检查终端节点
    app.MapHealthChecks("/health");
    // 不对约定路由做任何假设，也就是不使用约定路由，依赖用户的特性路由
    app.MapControllers();
    "ZhaiFanhuaBlog Application Started Successfully！".WriteLineSuccess();

    #endregion

    // 启动信息打印
    ConsoleInfo.Print();
    await app.RunAsync();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.Information("Application has closed");
    Log.CloseAndFlush();
}