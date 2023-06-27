﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:HttpGroupEnum
// Guid:f06f7e72-341f-43bf-80b0-375eecb05957
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-10-08 下午 10:28:41
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using System.ComponentModel;

namespace XiHan.Infrastructures.Requests.Https;

/// <summary>
/// 网络请求组别
/// </summary>
public enum HttpGroupEnum
{
    /// <summary>
    /// 公共
    /// </summary>
    [Description("公共")] Common,

    /// <summary>
    /// 本地
    /// </summary>
    [Description("本地")] Local,

    /// <summary>
    /// 远程
    /// </summary>
    [Description("远程")] Remote
}