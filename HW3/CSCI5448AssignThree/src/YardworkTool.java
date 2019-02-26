
public class YardworkTool extends Tool{

	public YardworkTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(12.00);	
	}
	public YardworkTool(String name) {
		super(name); 
		setPrice(12.00); 
		setType(); 
	}
	
	
	public void setType(){
		toolID = 5; 
	}
	

}
