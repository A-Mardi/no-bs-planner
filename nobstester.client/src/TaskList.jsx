/* TaskList.jsx */

import React from 'react';

function TaskList({ tasks, onDelete, onUpdate }) {
    return (
        <ul>
            {tasks.map((task) => (
                <li key={task.id}>
                    <h2>{task.name}</h2>
                    <p>{task.description}</p>
                    <p>Due Date: {new Date(task.dueDate).toLocaleDateString()}</p>
                    <p>Status: {task.isCompleted ? 'Completed' : 'Not Completed'}</p>
                    <button onClick={() => onUpdate(task)}>Edit</button>
                    <button onClick={() => onDelete(task.id)}>Delete</button>
                </li>
            ))}
        </ul>
    );
}

export default TaskList;
