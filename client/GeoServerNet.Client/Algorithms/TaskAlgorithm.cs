using System.Diagnostics;
using GeoServerNet.Client.Enums;
using Stateless;

namespace GeoServerNet.Client.Algorithms;

public interface ITaskAlgorithm
{
    TaskProcessState CurrentState { get; set; }
    public bool IsConfigured { get; set; }
    public TaskProcessState ExecuteTransaction(TaskCommand command);

}

public class TaskAlgorithm : ITaskAlgorithm
{
    public TaskProcessState CurrentState { get; set; }
    public bool IsConfigured { get; set; }
    
    private readonly StateMachine<TaskProcessState, TaskCommand> _stateMachine;

    public TaskAlgorithm()
    {
        _stateMachine = ConfigureStateMachine();
    }

    private StateMachine<TaskProcessState, TaskCommand> ConfigureStateMachine()
    {
        var stateMachine = new StateMachine<TaskProcessState, TaskCommand>(TaskProcessState.Inactive);
        
        stateMachine.OnTransitioned(OnTransition);

        stateMachine.Configure(TaskProcessState.Inactive)
            .Permit(TaskCommand.Configure, TaskProcessState.CompletedConfigure)
            .OnExit(() => IsConfigured = true);

        stateMachine.Configure(TaskProcessState.CompletedConfigure)
            .Permit(TaskCommand.Start, TaskProcessState.Sending);

        stateMachine.Configure(TaskProcessState.Running)
            .Permit(TaskCommand.Paused, TaskProcessState.Paused);

        stateMachine.Configure(TaskProcessState.Paused)
            .Permit(TaskCommand.Download, TaskProcessState.Download)
            .Permit(TaskCommand.Upload, TaskProcessState.Upload)
            .Permit(TaskCommand.Delete, TaskProcessState.Delete);
        
        stateMachine.Configure(TaskProcessState.Completed)
            .Permit(TaskCommand.Download, TaskProcessState.Download)
            .Permit(TaskCommand.Upload, TaskProcessState.Upload)
            .Permit(TaskCommand.Delete, TaskProcessState.Delete);
        
        // stateMachine.Configure(TaskProcessState.Terminated)
        //     .Permit(TaskCommand.Configure, )
        //stateMachine.Configure(TaskProcessState.Delete)
            
        
        //stateMachine.Configure(Task)
        
        //stateMachine.Configure(TaskProcessState.Running)
            

        return stateMachine;
    }
    
    public TaskProcessState ExecuteTransaction(TaskCommand command)
    {
        if (_stateMachine.CanFire(command))
            _stateMachine.FireAsync(command);
        else
            throw new InvalidOperationException($"Cannot transition from {CurrentState} via {command}");
        return CurrentState;
    }

    private static void OnTransition(StateMachine<TaskProcessState, TaskCommand>.Transition transition) =>
        Trace.WriteLine($"Transitioned from {transition.Source} to " +
                        $"{transition.Destination} via {transition.Trigger}.");
}