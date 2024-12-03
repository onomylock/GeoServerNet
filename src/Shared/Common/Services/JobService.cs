using System.Linq.Expressions;
using Hangfire;
using Shared.Application.Services;

namespace Shared.Common.Services;

public class JobService(IBackgroundJobClient backgroundJobClient) : IJobService
{
    public string AddEnque(Expression<Action> methodCall)
    {
        return backgroundJobClient.Enqueue(methodCall);
    }
    
    public string AddEnque<T>(Expression<Action<T>> methodCall)
    {
        return backgroundJobClient.Enqueue(methodCall);
    }
    
    public string AddContinuations(Expression<Action> methodCall, string jobid)
    {
        return backgroundJobClient.ContinueJobWith(jobid, methodCall);
    }
    
    public string AddContinuations<T>(Expression<Action<T>> methodCall, string jobid)
    {
        return backgroundJobClient.ContinueJobWith(jobid, methodCall);
    }
}