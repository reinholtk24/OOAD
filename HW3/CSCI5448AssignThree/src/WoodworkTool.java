
public class WoodworkTool extends Tool{

	public WoodworkTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(10.00);	
	}
	
	public WoodworkTool(String name) {
		super(name); 
		setPrice(10.00); 
		setType(); 
	}
	
	
	public void setType(){
		toolID = 4; 
	}
	
}
