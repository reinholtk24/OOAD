
public class PlumbingTool extends Tool {

	public PlumbingTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(10.00);	
	}
	
	public PlumbingTool(String name) {
		super(name); 
		setPrice(10.00); 
		setType(); 
	}
	
	
	
	public void setType(){
		toolID = 2; 
	}
	

}
