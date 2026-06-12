function TaskList({ tasks }) {
  return (
    <>
      {tasks.map(task => (
        <p key={task.id}>{task.id} {task.title} {task.isCompleted ? "✓" : "✗"}</p>
      ))}
    </>
  );
}

export default TaskList;