﻿namespace Shared.Models.Options;

public class HangfireOptions
{
    public int QueuePollIntervalSeconds { get; set; }
    public HangfireDbContextOptions DbContextOptions { get; set; }
}