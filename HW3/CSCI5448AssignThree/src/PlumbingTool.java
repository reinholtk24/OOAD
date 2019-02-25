
public class PlumbingTool extends ToolG {

	public PlumbingTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(10.00);	
	}
	
	
	public void setType(){
		toolID = 2; 
	}
	
	@Override
	public String getName(){
		return "Plumbing"; 
	}

}
