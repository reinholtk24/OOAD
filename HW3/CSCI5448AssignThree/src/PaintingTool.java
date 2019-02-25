
public class PaintingTool extends ToolG{

	public PaintingTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(3.00);	
	}
	
	
	public void setType(){
		toolID = 1; 
	}
	
	@Override
	public String getName(){
		return "Painting"; 
	}

}
