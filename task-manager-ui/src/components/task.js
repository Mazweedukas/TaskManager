export function createTask(id, title) {
  return {
    id,
    title,
    isCompleted: false
  };
}