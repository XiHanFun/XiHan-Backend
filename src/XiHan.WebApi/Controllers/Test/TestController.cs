﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:TestController
// Guid:845e3ab1-519a-407f-bd95-1204e9506dbd
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-06-17 上午 04:42:29
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using XiHan.Infrastructures.Apps;
using XiHan.Infrastructures.Infos;
using XiHan.Infrastructures.Responses.Results;
using XiHan.WebApi.Controllers.Bases;
using XiHan.Application.Common.Swagger;
using XiHan.Application.Filters;
using Microsoft.AspNetCore.RateLimiting;

namespace XiHan.WebApi.Controllers.Test;

/// <summary>
/// 系统测试
/// <code>包含：工具/客户端信息/IP信息/授权信息</code>
/// </summary>
[EnableCors("AllowAll")]
[ApiGroup(ApiGroupNames.Test)]
public class TestController : BaseApiController
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TestController()
    {
    }

    /// <summary>
    /// 客户端信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("ClientInfo")]
    public ActionResult<ResultDto> ClientInfo()
    {
        // 获取 HttpContext 和 HttpRequest 对象
        var httpContext = App.HttpContext!;
        HttpContexInfotHelper clientInfoHelper = new(httpContext);
        return ResultDto.Success(clientInfoHelper);
    }

    /// <summary>
    /// 过时
    /// </summary>
    /// <returns></returns>
    [Obsolete]
    [HttpGet("Obsolete")]
    public string Obsolete()
    {
        return "过时接口";
    }

    /// <summary>
    /// 授权
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpGet("Authorize")]
    public string Authorize()
    {
        return "授权接口";
    }

    /// <summary>
    /// 未实现或异常
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("Exception")]
    public string Exception()
    {
        throw new NotImplementedException("这是一个未实现或异常的接口");
    }

    /// <summary>
    /// 日志
    /// </summary>
    /// <param name="log"></param>
    /// <returns></returns>
    [HttpGet("LogInfo")]
    [TypeFilter(typeof(ActionFilterAsyncAttribute))]
    public ActionResult<ResultDto> LogInfo(string log)
    {
        return ResultDto.Success($"测试日志写入:{log}");
    }

    /// <summary>
    /// 限流
    /// </summary>
    /// <returns></returns>
    [HttpGet("RateLimiting")]
    [EnableRateLimiting("MyPolicy")]
    public ActionResult<ResultDto> RateLimiting()
    {
        return ResultDto.Success(DateTime.Now);
    }

    /// <summary>
    /// 资源过滤器
    /// </summary>
    /// <returns></returns>
    [HttpGet("ResourceFilterAttribute")]
    [TypeFilter(typeof(ResourceFilterAsyncAttribute))]
    public ActionResult<ResultDto> ResourceFilterAttribute()
    {
        return ResultDto.Success(DateTime.Now);
    }

    /// <summary>
    /// 异步资源过滤器
    /// </summary>
    /// <returns></returns>
    [HttpGet("ResourceFilterAsyncAttribute")]
    [TypeFilter(typeof(ResourceFilterAsyncAttribute))]
    public ActionResult<ResultDto> ResourceFilterAsyncAttribute()
    {
        return ResultDto.Success(DateTime.Now);
    }
}