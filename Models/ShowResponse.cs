namespace JPAsuncionAct1.Models
{
    public class ShowResponse
    {
        public double Score { get; set; }
        public required Show Show { get; set; }
    }

    public class Show
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public List<string> Genres { get; set; } = [];
        public string Status { get; set; } = string.Empty;
        public string Premiered { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public Image Image { get; set; } = new Image();
    }

    public class Image
    {
        public string Medium { get; set; } = string.Empty;
        public string Original { get; set; } = string.Empty;
    }
}
