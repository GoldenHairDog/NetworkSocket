﻿using NetworkSocket.Core;
using NetworkSocket.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkSocket.Tasks
{
    /// <summary>
    /// 定义任务行为接口
    /// </summary>
    public interface ITaskSetter
    {
        /// <summary>
        /// 获取任务的返回值类型
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// 设置任务的行为结果
        /// </summary>     
        /// <param name="value">数据值</param>   
        /// <returns></returns>
        bool SetResult(object value);

        /// <summary>
        /// 设置设置为异常
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns></returns>
        bool SetException(Exception ex);
    }

    /// <summary>
    /// 定义任务行为接口
    /// </summary>
    /// <typeparam name="TResult">结果类型</typeparam>
    public interface ITaskSetter<TResult> : ITaskSetter
    {
        /// <summary>
        /// 同步获取任务结果
        /// </summary>
        /// <returns></returns>
        TResult GetResult();

        /// <summary>
        /// 获取任务
        /// </summary>
        /// <returns></returns>
        Task<TResult> GetTask();

        /// <summary>
        /// 设置超时时间
        /// </summary>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        ITaskSetter<TResult> TimeoutAfter(TimeSpan timeout);

        /// <summary>
        /// 注册超时后的委托
        /// </summary>
        /// <param name="action">委托</param>
        /// <returns></returns>
        ITaskSetter<TResult> AfterTimeout(Action action);

        /// <summary>
        /// 注册超时后的委托
        /// </summary>
        /// <param name="action">委托</param>
        /// <returns></returns>
        ITaskSetter<TResult> AfterTimeout(Action<ITaskSetter<TResult>> action);
    }
}
