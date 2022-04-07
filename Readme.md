# Synchronization Context

This is a project holds a reproduce of the deadlock if the library code doesn't specify `ConfigureAwait(false)` and the caller code make a mistake by blocking on the SynchronizationContext.

How to use

1. Star this repo :-), actually, fork & clone this repo.

1. It is probably ok when there is no synchronization context:

    * Run the console app - no issue for either good code or not that good code;

        ```shell
        dotnet run --project .\ConsoleApp\
        ```

1. However, when the synchronization context exists, with some poor coding calling into async:
    * Run the WPF app, good code won't cause freeze, `Not that good` code causes a hang;

        ```shell
        dotnet run --project .\WPFApp
        ```
        ![image](https://user-images.githubusercontent.com/3674549/162096168-33e0f032-05a4-4c9b-8c40-61bf544195e7.png)

    * Dare you click the `not that correct code`? (it will freeze the application).

Same code provided in the ClassLib without `ConfigureAwait(false)` leading to different results - b/c:

1. WPF has synchronization context;
2. Async code expect to return back to the UI thread while UI thread is blocking upon getting `Result`.

As a **library author**, we couldn't determine how the callers (WPF/Console) uses our code, thus, always call `ConfigureAwait(false)` for async method as a best practice.

If you wish, fork this and fix it by appending `ConfigureAwait(false)` to the library code.
