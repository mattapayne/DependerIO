const getProfile = () => {
    const json = localStorage.getItem('profile') || '{}';
    return JSON.parse(json);
}

const deleteProfile = () => {
    localStorage.removeItem('profile');
}

const setProfile = (profile) => {
    localStorage.setItem('profile', JSON.stringify(profile));
}

export {
    getProfile,
    deleteProfile,
    setProfile
};