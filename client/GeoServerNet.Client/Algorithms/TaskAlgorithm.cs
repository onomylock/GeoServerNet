using System.Diagnostics;
using GeoServerNet.Client.Enums;
using GeoServerNet.Client.Options;
using GeoServerNet.Client.Services;
using Stateless;
using Stateless.Graph;

namespace GeoServerNet.Client.Algorithms;

public interface ITaskAlgorithm
{
    TaskProcessState CurrentState { get; }
    public bool IsConfigured { get; set; }
    public TaskProcessState ExecuteTransaction(TaskCommand command);
    public Task<TaskProcessState> ExecuteTransactionAsync(TaskCommand command);
    
}

public class TaskAlgorithm : ITaskAlgorithm
{
    public TaskProcessState CurrentState { get; private set; }
    public bool IsConfigured { get; set; }
    private readonly StateMachine<TaskProcessState, TaskCommand> _stateMachine;
    private readonly TaskOptions _taskOptions;
    
    public TaskAlgorithm(
        TaskOptions taskOptions, 
        ITaskClientService taskClientService)
    {
        _taskOptions = taskOptions;
        _stateMachine = ConfigureStateMachine();
    }

    private StateMachine<TaskProcessState, TaskCommand> ConfigureStateMachine()
    { 
        var stateMachine = new StateMachine<TaskProcessState, TaskCommand>(TaskProcessState.Inactive);

        stateMachine.Configure(TaskProcessState.Inactive)
            .Permit(TaskCommand.Configure, TaskProcessState.ConfigureStarted);
            
        stateMachine.Configure(TaskProcessState.ConfigureStarted)
            .OnEntryAsync(StartConfigureAsync)
            .Permit(TaskCommand.ConfigureComplete, TaskProcessState.ConfigureCompleted)
            .Permit(TaskCommand.Error, TaskProcessState.Terminated)
            .OnExitAsync(EndConfigureAsync);

        stateMachine.Configure(TaskProcessState.ConfigureCompleted)
            .Permit(TaskCommand.Send, TaskProcessState.Sending)
            .Permit(TaskCommand.Error, TaskProcessState.Terminated);

        stateMachine.Configure(TaskProcessState.Sending)
            .OnEntryAsync(StartSendTask)
            .Permit(TaskCommand.Start, TaskProcessState.Running)
            .Permit(TaskCommand.Error, TaskProcessState.Terminated);

        stateMachine.Configure(TaskProcessState.Running)
            .OnEntryAsync(RunTaskAsync)
            .Permit(TaskCommand.Pause, TaskProcessState.Paused)
            .Permit(TaskCommand.Error, TaskProcessState.Terminated)
            .Permit(TaskCommand.Complete, TaskProcessState.Completed)
            .Ignore(TaskCommand.Start);

        stateMachine.Configure(TaskProcessState.Paused)
            .OnEntryAsync(StopTaskRunningAsync)
            .Permit(TaskCommand.Delete, TaskProcessState.Deleted)
            .Permit(TaskCommand.Archive, TaskProcessState.Archiving)
            .Permit(TaskCommand.Error, TaskProcessState.Terminated);

        stateMachine.Configure(TaskProcessState.Archiving)
            .Permit(TaskCommand.Download, TaskProcessState.Downloading)
            .Permit(TaskCommand.Error, TaskProcessState.Terminated);
            
        stateMachine.Configure(TaskProcessState.Downloading)
            .Permit(TaskCommand.Error, TaskProcessState.Terminated)
            .Permit(TaskCommand.Inactive, TaskProcessState.Inactive)
            .OnExit( ( ) => _stateMachine.Fire(TaskCommand.Inactive));

        stateMachine.Configure(TaskProcessState.Completed)
            .Permit(TaskCommand.Delete, TaskProcessState.Deleted)
            .Permit(TaskCommand.Download, TaskProcessState.Downloading);

        stateMachine.Configure(TaskProcessState.Terminated)
            .Permit(TaskCommand.Inactive, TaskProcessState.Inactive);
            
        using var sr = new StreamWriter("file.txt");
        sr.Write(UmlDotGraph.Format(_stateMachine.GetInfo()));

        return stateMachine;
    }

    private Task StopTaskRunningAsync()
    {
        throw new NotImplementedException();
    }

    private Task RunTaskAsync()
    {
        throw new NotImplementedException();
    }

    private Task StartSendTask()
    {
        throw new NotImplementedException();
    }
    
    private Task EndConfigureAsync()
    {
        throw new NotImplementedException();
    }

    private Task StartConfigureAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Executes a transaction based on the provided command.
    /// </summary>
    /// <param name="command">The command to be executed.</param>
    /// <returns>The current state after the transaction.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the current state machine cannot transition with the given command.</exception>
    public TaskProcessState ExecuteTransaction(TaskCommand command)
    {
        if (_stateMachine.CanFire(command))
            _stateMachine.Fire(command);
        else
            throw new InvalidOperationException($"Cannot transition from {CurrentState} via {command}");
        return CurrentState;
    }

    public async Task<TaskProcessState> ExecuteTransactionAsync(TaskCommand command)
    {
        if (_stateMachine.CanFire(command))
            await _stateMachine.FireAsync(command);
        else
            throw new InvalidOperationException($"Cannot transition from {CurrentState} via {command}");
        return CurrentState;
    }

    private static void OnTransition(StateMachine<TaskProcessState, TaskCommand>.Transition transition) =>
        Trace.WriteLine($"Transitioned from {transition.Source} to " +
                        $"{transition.Destination} via {transition.Trigger}.");
}