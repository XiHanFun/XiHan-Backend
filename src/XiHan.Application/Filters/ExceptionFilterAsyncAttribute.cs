﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:ExceptionFilterAsyncAttribute
// Guid:0c556f22-3f97-4ea7-aa0c-78d8d5722cc4
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-06-15 下午 11:13:23
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Security.Authentication;
using System.Security.Claims;
using XiHan.Infrastructures.Apps.Configs;
using XiHan.Infrastructures.Responses.Results;

namespace XiHan.Application.Filters;

/// <summary>
/// 异步异常处理过滤器属性（一般用于捕捉异常）
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class ExceptionFilterAsyncAttribute : Attribute, IAsyncExceptionFilter
{
    // 日志开关
    private readonly bool _exceptionLogSwitch = AppSettings.LogConfig.Exception.GetValue();

    private readonly ILogger _logger = Log.ForContext<ExceptionFilterAsyncAttribute>();

    /// <summary>
    /// 当异常发生时
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        // 异常是否被处理过，没有则在这里处理
        if (context.ExceptionHandled == false)
        {
            // 未实现异常
            if (context.Exception is NotImplementedException)
            {
                context.Result = new JsonResult(ResultDto.NotImplemented());
            }
            // 认证授权异常
            else if (context.Exception is AuthenticationException)
            {
                context.Result = new JsonResult(ResultDto.Unauthorized(context.Exception.Message));
            }
            // 应用级异常
            else if (context.Exception is ApplicationException)
            {
                context.Result = new JsonResult(ResultDto.BadRequest(context.Exception.Message));
            }
            else
            {
                // 其他异常，返回服务器错误，不直接明文显示
                context.Result = new JsonResult(ResultDto.InternalServerError());
                // 获取控制器、路由信息
                var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                // 获取请求的方法
                var method = actionDescriptor!.MethodInfo;
                // 获取 HttpContext 和 HttpRequest 对象
                var httpContext = context.HttpContext;
                var httpRequest = httpContext.Request;
                // 获取客户端 Ip 地址
                var remoteIp = httpContext.Connection.RemoteIpAddress == null ? string.Empty : httpContext.Connection.RemoteIpAddress.ToString();
                // 获取请求的 Url 地址(域名、路径、参数)
                var requestUrl = httpRequest.Host.Value + httpRequest.Path + httpRequest.QueryString.Value;
                // 获取操作人（必须授权访问才有值）"userId" 为你存储的 claims type，jwt 授权对应的是 payload 中存储的键名
                var userId = httpContext.User.FindFirstValue("UserId");
                // 写入日志
                var info = $"\t 请求Ip：{remoteIp}\n" +
                           $"\t 请求地址：{requestUrl}\n" +
                           $"\t 请求方法：{method}\n" +
                           $"\t 操作用户：{userId}";
                if (_exceptionLogSwitch)
                    _logger.Error(context.Exception, $"系统异常\n{info}");
            }
        }
        // 标记异常已经处理过了
        context.ExceptionHandled = true;
        await Task.CompletedTask;
    }
}