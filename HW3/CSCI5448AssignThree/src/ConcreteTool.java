
public class ConcreteTool extends ToolG {

	public ConcreteTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(7.00);	
	}
	
	
	public void setType(){
		toolID = 3; 
	}
	
	@Override
	public String getName(){
		return "Concrete"; 
	}

}
