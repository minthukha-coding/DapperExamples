using DapperExamples.DapperExamples;
using DapperExamples.Share;

DapperService dapperService = new DapperService();

DapperExample dapperExample = new DapperExample(dapperService);
dapperExample.Run();

Console.ReadKey();