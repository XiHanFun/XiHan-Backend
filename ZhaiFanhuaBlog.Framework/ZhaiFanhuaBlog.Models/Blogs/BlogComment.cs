﻿// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:BlogComment
// Guid:60383ed1-8cd3-43d1-85e8-8b3dc45cdc7e
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 06:25:47
// ----------------------------------------------------------------

using SqlSugar;
using System.Net;
using ZhaiFanhuaBlog.Models.Bases;
using ZhaiFanhuaBlog.Utils.Formats;

namespace ZhaiFanhuaBlog.Models.Blogs;

/// <summary>
/// 文章评论表
/// </summary>
public class BlogComment : BaseEntity
{
    /// <summary>
    /// 评论者
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// 父级评论
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public Guid? ParentId { get; set; }

    /// <summary>
    /// 所属文章
    /// </summary>
    public Guid ArticleId { get; set; }

    /// <summary>
    /// 评论内容
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(4000)")]
    public string TheContent { get; set; } = string.Empty;

    /// <summary>
    /// 评论点赞数
    /// </summary>
    public int PollCount { get; set; } = 0;

    /// <summary>
    /// 是否置顶 是(true)否(false)，只能置顶没有父级评论的项
    /// </summary>
    public bool IsTop { get; set; } = false;

    /// <summary>
    /// 评论者Ip(显示地区)
    /// </summary>
    [SugarColumn(ColumnDataType = "varbinary(16)", IsNullable = true)]
    public virtual byte[]? CommentIp
    {
        get => _CommentIp == null ? null : IpFormatHelper.FormatIPAddressToByte(_CommentIp);
        set => _CommentIp = value == null ? null : IpFormatHelper.FormatByteToIPAddress(value);
    }

    /// <summary>
    /// 评论者Ip
    /// </summary>
    private IPAddress? _CommentIp;

    /// <summary>
    /// 代理信息
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(100)", IsNullable = true)]
    public string? Agent { get; set; }
}