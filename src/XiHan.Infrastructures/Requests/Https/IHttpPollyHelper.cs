﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:IHttpPollyHelper
// Guid:6cd09b99-c24d-4ef5-b8ca-15aa97f898c5
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-12-06 下午 03:22:05
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

namespace XiHan.Infrastructures.Requests.Https;

/// <summary>
/// IHttpPollyHelper
/// </summary>
public interface IHttpPollyHelper
{
    /// <summary>
    /// Get 请求
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<TEntity?> GetAsync<TEntity>(HttpEnum httpEnum, string url, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Get 请求
    /// </summary>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<string> GetAsync(HttpEnum httpEnum, string url, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Post 请求
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TREntity"></typeparam>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="request"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<TEntity?> PostAsync<TEntity, TREntity>(HttpEnum httpEnum, string url, TREntity request, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Post 请求 上传文件
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="fileStream"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<TEntity?> PostAsync<TEntity>(HttpEnum httpEnum, string url, FileStream fileStream, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Post 请求
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="request"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<TEntity?> PostAsync<TEntity>(HttpEnum httpEnum, string url, string request, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Post 请求
    /// </summary>
    /// <typeparam name="TREntity"></typeparam>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="request"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<string> PostAsync<TREntity>(HttpEnum httpEnum, string url, TREntity request, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Post 请求
    /// </summary>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="request"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<string> PostAsync(HttpEnum httpEnum, string url, string request, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Put 请求
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TREntity"></typeparam>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="request"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<TEntity?> PutAsync<TEntity, TREntity>(HttpEnum httpEnum, string url, TREntity request, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Put 请求
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="request"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<TEntity?> PutAsync<TEntity>(HttpEnum httpEnum, string url, string request, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Delete 请求
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="httpEnum"></param>
    /// <param name="url"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    Task<TEntity?> DeleteAsync<TEntity>(HttpEnum httpEnum, string url, Dictionary<string, string>? headers = null);
}