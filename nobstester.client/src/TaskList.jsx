/*TaskList.jsx*/

import React from 'react';

function TaskList({ tasks }) {
    return (
        <ul>
            {tasks.map((task) => (
                <li key={task.id}>
                    <h2>{task.name}</h2>
                    <p>{task.description}</p>
                    <p>Due Date: {new Date(task.dueDate).toLocaleDateString()}</p>
                    <p>Status: {task.isCompleted ? 'Completed' : 'Not Completed'}</p>
                </li>
            ))}
        </ul>
    );
}

export default TaskList;
