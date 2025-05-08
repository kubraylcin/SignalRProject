namespace SignalRWebUI.Dtos.RapidApiDtos
{
    public class TastyApiResultDto
    {
        public List<ResultTastyApi> results { get; set; }
    }
    public class ResultTastyApi
    {
        public string Name { get; set; }
        public string original_video_url { get; set; }
        public int total_time_minutes { get; set; }
        public string thumbnail_url { get; set; }

    }
}
