namespace KeepCalmAndMIC.Models
{
	public interface IIdentifiable<T>
	{
		T Id { get; }
	}
}