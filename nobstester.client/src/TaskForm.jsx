/*TaskForm.jsx*/

import React, { useState, useEffect } from 'react';

const TaskForm = ({ onSubmit, currentTask }) => {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [date, setDate] = useState('');
    const [isCompleted, setIsCompleted] = useState(false);

    useEffect(() => {
        if (currentTask) {
            setName(currentTask.name);
            setDescription(currentTask.description);
            setDate(currentTask.dueDate ? currentTask.dueDate.split('T')[0] : '');
            setIsCompleted(currentTask.isCompleted);
        }
    }, [currentTask]);

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit({ name, description, isCompleted, dueDate: date });
        setName('');
        setDescription('');
        setDate('');
        setIsCompleted(false);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div className="input-container">
                <input
                    type="text"
                    placeholder="Task name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    required
                />
                <textarea
                    placeholder="Task description"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    required
                />
                <input
                    type="date"
                    value={date}
                    onChange={(e) => setDate(e.target.value)}
                    required
                />
            </div>
            <button type="submit">Save Task</button>
        </form>
    );
};

export default TaskForm;
