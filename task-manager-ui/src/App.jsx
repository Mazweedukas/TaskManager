import { useState } from "react";

function App() {
  const [tasks, setTasks] = useState([
    {
      id: 1,
      title: "Some Task",
      isCompleted: false
    }
  ]);

  const [newTaskTitle, setNewTaskTitle] = useState("");

  return (
    <>
      <h1>Task Manager</h1>

      <input
        value={newTaskTitle}
        onChange={(e) => setNewTaskTitle(e.target.value)}
      />

      {tasks.map(task => (
        <p key={task.id}>{task.title}</p>
      ))}

      <button onClick={() => setTasks ([
        "Change",
        "Things"
        ])}>Change current</button>

      <button onClick={() => setTasks ([
      ...tasks,
            {
              id: tasks.length + 1,
              title: "newTask",
              isCompleted: false
            }
      ])}>Add</button>

      <button onClick={() => setTasks ((tasks.slice(0, -1)))}>Remove One</button>

      <button onClick={() => setTasks ([])}>Clear</button>

      <button
        onClick={() =>
          setTasks([
            ...tasks,
            {
              id: tasks.length + 1,
              title: newTaskTitle,
              isCompleted: false
            }
          ])
        }
      >
        Add from other
      </button>

    </>
  );
}

export default App;