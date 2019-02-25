
public class YardworkTool extends ToolG{

	public YardworkTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(12.00);	
	}
	
	
	public void setType(){
		toolID = 5; 
	}
	
	@Override
	public String getName(){
		return "Yardwork"; 
	}

}
