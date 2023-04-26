﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:SysRole
// long:26b82e42-87a7-477b-af80-59456336a22b
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 04:42:51
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Models.Bases.Entity;

namespace XiHan.Models.Syses;

/// <summary>
/// 系统角色表
/// </summary>
/// <remarks>记录创建，修改，删除信息</remarks>
[SugarTable(TableName = "Sys_Role")]
public class SysRole : BaseDeleteEntity
{
    /// <summary>
    /// 父级角色
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public long? ParentId { get; set; }

    /// <summary>
    /// 角色代码
    /// 如：admin
    /// </summary>
    [SugarColumn(Length = 20)]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 角色名称
    /// </summary>
    [SugarColumn(Length = 10)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 角色描述
    /// </summary>
    [SugarColumn(Length = 50, IsNullable = true)]
    public string? Description { get; set; }

    #region 其他字段

    /// <summary>
    /// 用户个数
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public int UserCount { get; set; }

    #endregion
}