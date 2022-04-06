using ClassLib;

using (MyCurl myCurl = new MyCurl())
{
    Uri targetUri = new Uri("https://www.google.com");
    // Correct usage;
    string result = await myCurl.CurlAsync(targetUri);
    Console.WriteLine(result);

    Console.WriteLine("First request done. Press any key to continue...");
    Console.ReadKey(intercept: true);

    // Not that correct usage:
    string result2 = myCurl.CurlAsync(targetUri).Result;
    Console.WriteLine(result2);
}