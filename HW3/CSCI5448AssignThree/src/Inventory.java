import java.util.List;
import java.util.*; 


public class Inventory {
	private List<Tool> toolList;
	private Tool tool;
	
	public Inventory() {
		toolList = new ArrayList<Tool>(); 
		Tool p1 = new PaintingTool("PaintingTool1"); 
		Tool p2 = new PaintingTool("PaintingTool2"); 
		Tool p3 = new PaintingTool("PaintingTool3"); 
		Tool p4 = new PaintingTool("PaintingTool4"); 
		Tool w1 = new WoodworkTool("WoodworkTool1");
		Tool w2 = new WoodworkTool("WoodworkTool2");
		Tool w3 = new WoodworkTool("WoodworkTool3");
		Tool w4 = new WoodworkTool("WoodworkTool4");
		Tool c1 = new ConcreteTool("ConcreteTool1");
		Tool c2 = new ConcreteTool("ConcreteTool2");
		Tool c3 = new ConcreteTool("ConcreteTool3");
		Tool c4 = new ConcreteTool("ConcreteTool4");
		Tool y1 = new YardworkTool("YardworkTool1"); 
		Tool y2 = new YardworkTool("YardworkTool2"); 
		Tool y3 = new YardworkTool("YardworkTool3"); 
		Tool y4 = new YardworkTool("YardworkTool4"); 
		Tool pl1 = new PlumbingTool("PlumbingTool1");
		Tool pl2 = new PlumbingTool("PlumbingTool2");
		Tool pl3 = new PlumbingTool("PlumbingTool3");
		Tool pl4 = new PlumbingTool("PlumbingTool4");
		
		toolList.add(p1);
		toolList.add(p2);
		toolList.add(p3);
		toolList.add(p4);
		toolList.add(w1);
		toolList.add(w2);
		toolList.add(w3);
		toolList.add(w4);
		toolList.add(c1);
		toolList.add(c2);
		toolList.add(c3);
		toolList.add(c4);
		toolList.add(y1);
		toolList.add(y2);
		toolList.add(y3);
		toolList.add(y4);
		toolList.add(pl1);
		toolList.add(pl2);
		toolList.add(pl3);
		toolList.add(pl4);
	}
	
	public int getNumOfTools() {
		return toolList.size();
	}
	
	public void removeTool(Tool tool) {
		toolList.remove(tool);
	}
	// I think this is wrong we should pass in a Tool and add a Tool object to the list
	public void addTool(Tool tool) {
		toolList.add(tool);
	}
	
	public int getType() {
		/**
		 * return the type of tool but there needs to be some communication maybe a variable that is what
		 * Google says equates to composition
		 */
		return tool.getType();
	}
	
	public List<Tool> list()
	{
		return toolList; 
	}
	
	/**
	 * Do we need one of these for Inventory?
	 */
	public String toString() {
		return String.format("Tool Name: ", tool.toolName);
	}
	
}
