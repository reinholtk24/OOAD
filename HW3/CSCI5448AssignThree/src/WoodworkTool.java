
public class WoodworkTool extends ToolG{

	public WoodworkTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(10.00);	
	}
	
	
	public void setType(){
		toolID = 4; 
	}
	
	@Override
	public String getName(){
		return "Woodwork"; 
	}

}
