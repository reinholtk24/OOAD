
public class Regular extends Customer {

	Regular(String name)
	{
		super(name); 
		setMaxNights(5); 
		setMaxTools(3); 
		setMinNights(3); 
		setMinTools(1); 
	}
	
	@Override
	public void setType()
	{
		type = 3; 
	}
	
	@Override
	public String getType()
	{
		return "Regular"; 
	}
}
