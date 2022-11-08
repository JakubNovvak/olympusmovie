import Reack from 'react';
import styles from './ToggleSwitch.module.css';


const ToggleSwitch = ({ }) => {



    return (
        <div className={styles.main}>
            <label className={styles.switch}>
                <input type="checkbox" />
                <span className={styles.slider}/>
            </label>
        </div>
        );

}

export default ToggleSwitch;