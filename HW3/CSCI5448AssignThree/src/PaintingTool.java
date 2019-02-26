
public class PaintingTool extends Tool{

	public PaintingTool(double price, String name, int id) {
		super(price, name, id);
		setPrice(3.00);	
	}
	
	public PaintingTool(String name) {
		super(name); 
		setPrice(3.00); 
		setType(); 
	}

	
	public void setType(){
		toolID = 1; 
	}
	


}
