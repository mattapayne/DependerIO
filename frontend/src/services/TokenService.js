const getAccessToken = () => {
    return localStorage.getItem('access_token');
};

const setAccessToken = (token) => {
    localStorage.setItem('access_token', token);
}

const deleteAccessToken = () => {
    localStorage.removeItem('access_token');
}

const getIdToken = () => {
    return localStorage.getItem('id_token');
};

const setIdToken = (token) => {
    localStorage.setItem('id_token', token);
}

const deleteIdToken = () => {
    localStorage.removeItem('id_token');
}

export {
    getAccessToken,
    setAccessToken,
    deleteAccessToken,
    getIdToken,
    setIdToken,
    deleteIdToken
};