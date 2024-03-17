import TextField from '@mui/material/TextField';

function AuthEmailTextField()
{
    return (
        <TextField
            id="email"
            name="email"
            margin="normal"
            required
            fullWidth
            size='normal'
            label="Adres email"
            autoComplete="email"
            autoFocus />
    );
}

export default AuthEmailTextField;