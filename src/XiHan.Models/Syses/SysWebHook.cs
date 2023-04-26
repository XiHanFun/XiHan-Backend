﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2023 ZhaiFanhua All Rights Reserved.
// FileName:SysWebHook
// Guid:e034c85d-9537-4580-ad6b-5974c27915e1
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2023-04-19 上午 02:46:34
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Models.Bases.Entity;

namespace XiHan.Models.Syses;

/// <summary>
/// 系统网络挂钩配置表
/// </summary>
/// <remarks>记录创建，修改信息</remarks>
[SugarTable(TableName = "Sys_WebHook")]
public class SysWebHook : BaseModifyEntity
{
    /// <summary>
    /// 是否可用
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// 机器人类型
    /// WebHookTypeEnum
    /// </summary>
    public int WebHookType { get; set; }

    /// <summary>
    /// 网络挂钩地址
    /// 钉钉 https://oapi.dingtalk.com/robot/send
    /// 企业微信 https://qyapi.weixin.qq.com/cgi-bin/webhook/send
    /// </summary>
    [SugarColumn(Length = 100)]
    public string WebHookUrl { get; set; } = string.Empty;

    /// <summary>
    /// 访问令牌
    /// 钉钉 AccessToken
    /// 企业微信 Key
    /// </summary>
    [SugarColumn(Length = 100)]
    public string AccessTokenOrKey { get; set; } = string.Empty;

    /// <summary>
    /// 机密
    /// 钉钉
    /// </summary>
    [SugarColumn(Length = 100, IsNullable = true)]
    public string? Secret { get; set; } = string.Empty;

    /// <summary>
    /// 上传地址
    /// 企业微信 https://qyapi.weixin.qq.com/cgi-bin/webhook/upload_media
    /// </summary>
    [SugarColumn(Length = 100, IsNullable = true)]
    public string? UploadkUrl { get; set; } = string.Empty;
}