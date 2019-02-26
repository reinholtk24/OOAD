
public class Tool {
	double toolPrice;
	String toolName;
	int toolID;
	
	public Tool(double price, String name, int id) {
		this.toolPrice = price;
		this.toolName = name;
		this.toolID = id;
	}
	public Tool(String name){
		this.toolName = name; 
	}
	
	public double getPrice() {
		return this.toolPrice;
	}
	
	public void setPrice(double toolPrice) {
		this.toolPrice = toolPrice;
	}
	
	public String getName() {
		return this.toolName;
	}
	
	public void setName(String toolName) {
		this.toolName = toolName;
	}
	
	public int getType() {
		return this.toolID;
	}
	
	public void setType(int toolID) {
		this.toolID = toolID;
	}
}
