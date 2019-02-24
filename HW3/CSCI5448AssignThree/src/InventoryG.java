import java.util.List;


public class InventoryG {
	private List<ToolG> toolList;
	private ToolG tool;
	
	public InventoryG() {
		
	}
	
	public int getNumOfTools() {
		return toolList.size();
	}
	
	public void removeTool(ToolG tool) {
		toolList.remove(tool);
	}
	// I think this is wrong we should pass in a Tool and add a Tool object to the list
	public void addTool(ToolG tool) {
		toolList.add(tool);
	}
	
	public int getType() {
		/**
		 * return the type of tool but there needs to be some communication maybe a variable that is what
		 * Google says equates to composition
		 */
		return tool.getType();
	}
	
}
