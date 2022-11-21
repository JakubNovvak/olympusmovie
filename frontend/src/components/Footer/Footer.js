import facebookLogo from '../../assets/facebooklogo.png';
import discordLogo from '../../assets/discordlogo.png';
import twitterlogo from '../../assets/twitterlogo.png';
import instagramlogo from '../../assets/instagramlogo.png';
import styles from './Footer.module.css';
import Container from '@mui/material/Container';
import Box from '@mui/material/Box';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';

const Footer = () => {
    return (
        <footer>
            <section className={styles.Footer}>

                <section className={styles.FooterSocial}>
                    <img src={facebookLogo} alt="facebook"></img>
                    <img src={discordLogo} alt="discord"></img>
                    <img src={instagramlogo} alt="instagram"></img>
                    <img src={twitterlogo} alt="twitter"></img>
                </section>

                <hr className={styles.FooterContentSeparator} />

                <section className={styles.FooterLinks}>
                    <div className={styles.FooterLinksCenter}>
                        |
                        <a href=''>O nas</a>
                        <a href=''>Ciasteczka</a>
                        <a href=''>Kontakt</a>
                        <a href=''>Support</a>
                        <a href=''>FAQ</a>
                        |
                    </div>
                </section>

                <section className={styles.FooterCopyright}>
                    Copyright © 2022 OlympusMovie
                </section>

            </section>
        </footer>
    );
}

const FooterTwo = ({ }) => {

    return (

        <footer>

            <Box bgcolor="black">
                <Container maxWidth="lg">
                    <Grid container spacing={0} direction="column" alignItems="center" justifyContent="center">

                        <Grid item>
                            <Box className={styles.BoxSocials}>
                                <img src={facebookLogo} alt="facebook"></img>
                                <img src={discordLogo} alt="discord"></img>
                                <img src={instagramlogo} alt="instagram"></img>
                                <img src={twitterlogo} alt="twitter"></img>
                            </Box>
                            <hr className={styles.FooterContentSeparator} />
                        </Grid>

                        <Grid item>
                            <Box color="white">
                                |
                                <Link className={styles.FooterLink}>O nas</Link>
                                <Link className={styles.FooterLink}>Kontakt</Link>
                                <Link className={styles.FooterLink}>Ciasteczka</Link>
                                <Link className={styles.FooterLink}>Support</Link>
                                <Link className={styles.FooterLink}>FAQ</Link>
                                |
                            </Box>
                        </Grid>

                        <Grid item>
                            <Box className={styles.FooterCopyright}>
                                Copyright © 2022 OlympusMovie
                            </Box>
                        </Grid>
                    </Grid>
                </Container>
            </Box>

        </footer>

    );

}

export default Footer;