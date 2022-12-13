﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:AppServiceAttribute
// Guid:72f7e263-7daa-4767-b8e2-3e73f5e0b8e2
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-12-04 下午 10:44:55
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using ZhaiFanhuaBlog.Infrastructure.Enums;

namespace ZhaiFanhuaBlog.Infrastructure.App.Service;

/// <summary>
/// 标记服务
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class AppServiceAttribute : Attribute
{
    /// <summary>
    /// 服务声明周期
    /// 不给默认值的话注册的是AddSingleton
    /// </summary>
    public LifeTimeEnum ServiceLifetime { get; set; } = LifeTimeEnum.Singleton;

    /// <summary>
    /// 指定服务类型
    /// </summary>
    public Type? ServiceType { get; set; }

    /// <summary>
    /// 是否可以从第一个接口获取服务类型
    /// </summary>
    public bool InterfaceServiceType { get; set; }
}