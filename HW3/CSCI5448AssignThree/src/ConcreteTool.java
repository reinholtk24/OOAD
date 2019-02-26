
public class ConcreteTool extends Tool {

	public ConcreteTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(7.00);	
	}
	
	public ConcreteTool(String name) {
		super(name); 
		setPrice(7.00); 
		setType(); 
	}
	
	
	public void setType(){
		toolID = 3; 
	}


}
