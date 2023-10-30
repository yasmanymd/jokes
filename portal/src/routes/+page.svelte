<script>
	import {
		Button,
		Card,
		CardBody,
		CardTitle,
		Ribbon,
		El,
		Icon,
		Table,
		TableBody,
		TableCell,
		TableHead,
		TableRow
	} from 'yesvelte';
	import { onMount } from 'svelte';

	let randomQuote = 'Loading...';

	function getRandom() {
		fetch('http://localhost:3000/api/Jokes/GetRandom')
			.then((response) => response.json())
			.then((data) => {
				randomQuote = data.value;
			})
			.catch((error) => {
				console.log(error);
			});
	}

	onMount(async () => {
		getRandom();
	});
</script>

<h1 style="text-align: center; margin-top: 20px; margin-bottom: 10px;">Welcome to My Example</h1>

<El container>
	<El row>
		<El col="9">
			<Table hover>
				<TableHead>
					<TableRow>
						<TableCell>Name</TableCell>
						<TableCell>Title</TableCell>
						<TableCell>Email</TableCell>
						<TableCell>Role</TableCell>
					</TableRow>
				</TableHead>
				<TableBody>
					<TableRow>
						<TableCell>Emmy Levet</TableCell>
						<TableCell>VP Product Management, Accounting</TableCell>
						<TableCell>elevet4@senate.gov</TableCell>
						<TableCell>Admin</TableCell>
					</TableRow>
				</TableBody>
			</Table>
		</El>
		<El col="3">
			<El row>
				<El colSm="12" colMd="12">
					<Card>
						<CardBody>
							<CardTitle>Joke of Day</CardTitle>
							<p>
								{randomQuote}
							</p>
							<Button
								color="primary"
								on:click={async () => {
									getRandom();
								}}>Get another one</Button
							>
						</CardBody>
						<Ribbon bgColor="success" elementPosition="end"
							><Icon name="bell" color="light" />
						</Ribbon>
					</Card>
				</El>
			</El>
		</El>
	</El>
</El>
