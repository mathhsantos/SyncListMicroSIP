namespace SyncListMicroSIP.Dtos
{
    public class ResponseDto<T>
    {
        public int Refresh { get; set; }
        public T Items { get; set; }

        public ResponseDto(T items) 
        { 
            Refresh = 0;
            Items = items;
        }
    }
}
