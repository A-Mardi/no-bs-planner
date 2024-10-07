import React from 'react';

const TaskList = ({ tasks, onDelete, onUpdate }) => {
    return (
        <div className="task-list">
            <h2>Task List</h2>
            <ul>
                {tasks.map((task) => (
                    <li key={task.id}>
                        {task.name} - {task.completed ? 'Completed' : 'Not Completed'}
                        <button onClick={() => onUpdate(task)}>Update</button>
                        <button onClick={() => onDelete(task.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default TaskList;