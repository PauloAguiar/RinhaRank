using System.Text;

string rootPath = @"./rinha-repo/resultados";

Directory.CreateDirectory("./results/");

foreach (var filePath in Directory.GetFiles(rootPath, "simulation.log", SearchOption.AllDirectories))
{
    var fi = new FileInfo(filePath);
    var foldername = fi.Directory.Parent.Name;
    string[] lines = File.ReadAllLines(filePath);

    using (StreamWriter writer = new StreamWriter("./results/" + foldername + ".csv", false, Encoding.UTF8))
    {
        writer.WriteLine("Folder,Type,StartTime,EndTime,ElapsedTime,Result");

        foreach (string line in lines)
        {
            if (line.StartsWith("REQUEST"))
            {
                var parts = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 5)
                {
                    string type = parts[1];
                    string startTime = parts[2];
                    string endTime = parts[3];
                    string result = parts[4];
                    TimeSpan elapsedTime = CalculateElapsedTime(startTime, endTime);

                    writer.WriteLine($"\"{foldername}\",\"{type}\",\"{startTime}\",\"{endTime}\",\"{elapsedTime.TotalMilliseconds}\",\"{result}\"");
                }
            }
        }

    }
}

TimeSpan CalculateElapsedTime(string startTime, string endTime)
{
    var startDateTime = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(startTime));
    var endDateTime = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(endTime));

    return endDateTime - startDateTime;
}