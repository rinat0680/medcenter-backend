namespace MedicalCenterApi;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }        // Название услуги
    public string Description { get; set; } // Краткое описание
    public decimal Price { get; set; }      // Стоимость
    public TimeSpan Duration { get; set; }  // Длительность
}
