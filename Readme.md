# Synchronization Context

Run the console app - no issue for either good code or not that good code;

Run the WPF app, good code won't cause freeze, `Not that good` code causes a hang;

Same code provided in the ClassLib without `ConfigureAwait(false)` leading to different results - b/c:

1. WPF has synchronization context;
2. Async code expect to return back to the UI thread while UI thread is blocking upon getting `Result`.

As a library owner, we couldn't determine how the callers (WPF/Console) uses our code, thus, always call `ConfigureAwait(false)` for async method as a best practice.
